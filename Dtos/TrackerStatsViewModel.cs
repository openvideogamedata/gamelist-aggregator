namespace community.Dtos;

public class TrackerStatsViewModel
{
    public int ToPlay { get; set; } = 0;
    public int Playing { get; set; } = 0;
    public int Played { get; set; } = 0;
    public int Beated { get; set; } = 0;
    public int Abandoned { get; set; } = 0;
    public int None { get; set; } = 0;

    public TrackerStatsViewModel() { }

    public TrackerStatsViewModel(List<GroupItem>? topWinners)
    {
        if (topWinners != null && topWinners.Any())
        {
            var trackersOnList = topWinners.Select(x => x.TrackStatus).ToList();
            if (trackersOnList != null && trackersOnList.Any())
            {
                foreach (var trackStatus in trackersOnList)
                {
                    if (trackStatus == TrackStatus.ToPlay)
                        ToPlay++;
                    else if (trackStatus == TrackStatus.Playing)
                        Playing++;
                    else if (trackStatus == TrackStatus.Played)
                        Played++;
                    else if (trackStatus == TrackStatus.Beaten)
                        Beated++;
                    else if (trackStatus == TrackStatus.Abandoned)
                        Abandoned++;
                    else
                        None++;
                }
            }
        }
    }

    public void Reset()
    {
        ToPlay = 0;
        Playing = 0;
        Played = 0;
        Beated = 0;
        Abandoned = 0;
        None = 0;
    }
}