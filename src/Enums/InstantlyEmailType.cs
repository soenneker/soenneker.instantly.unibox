using Ardalis.SmartEnum;

namespace Soenneker.Instantly.Unibox.Enums;

public class InstantlyEmailType : SmartEnum<InstantlyEmailType>
{
    public static readonly InstantlyEmailType Sent = new(nameof(Sent).ToLowerInvariant(), 1);
    public static readonly InstantlyEmailType Received = new(nameof(Received).ToLowerInvariant(), 2);
    public static readonly InstantlyEmailType All = new(nameof(All).ToLowerInvariant(), 3);
    public static readonly InstantlyEmailType Manual = new(nameof(Manual).ToLowerInvariant(), 4);

    private InstantlyEmailType(string name, int value) : base(name, value)
    {
    }
}