using Intellenum;

namespace Soenneker.Instantly.Unibox.Enums;

[Intellenum(typeof(string))]
public partial class InstantlyEmailType
{
    public static readonly InstantlyEmailType Sent = new("sent");
    public static readonly InstantlyEmailType Received = new("received");
    public static readonly InstantlyEmailType All = new("all");
    public static readonly InstantlyEmailType Manual = new("manual");
}