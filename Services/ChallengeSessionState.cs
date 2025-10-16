using System.Collections.Generic;
using community.Dtos;

namespace community.Services;

/// <summary>
/// Maintains micro challenge state for the current Blazor circuit without persisting to the database.
/// </summary>
public sealed class ChallengeSessionState
{
    private readonly Dictionary<string, MicroChallengeDto> _challenges = new();

    public MicroChallengeDto? Get(string challengeId)
    {
        if (string.IsNullOrWhiteSpace(challengeId))
            return null;

        _challenges.TryGetValue(challengeId, out var challenge);
        return challenge;
    }

    public void Store(MicroChallengeDto challenge)
    {
        if (challenge is null)
            return;

        _challenges[challenge.ChallengeId] = challenge;
    }

    public void Clear(string challengeId)
    {
        if (string.IsNullOrWhiteSpace(challengeId))
            return;

        _challenges.Remove(challengeId);
    }

    public void Reset()
    {
        _challenges.Clear();
    }
}
