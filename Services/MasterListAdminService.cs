using community.Dtos;
using community.Utils;

namespace community.Services;

public class MasterListAdminService
{
    public CreateFinalGameListDto CreateEmptyForm()
    {
        return new CreateFinalGameListDto
        {
            SocialComments = 0,
            PinnedPriority = 0
        };
    }

    public string GenerateSlug(string? source)
    {
        var baseText = source ?? string.Empty;
        return baseText.ToUrlSlug();
    }
}
