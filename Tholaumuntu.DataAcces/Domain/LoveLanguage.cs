using System.ComponentModel;

namespace Tholaumuntu.DataAcces.Domain
{
    public enum LoveLanguage
    {
        [Description("Words of Affirmation")]
        WordsOfAffirmation = 1,
        [Description("Act of Service")]
        ActOfService,
        [Description("Receiving Gifts")]
        ReceivingGifts,
        [Description("Quality Time")]
        QualityTime,
        [Description("Physical Touch")]
        PhysicalTouch
    }

    public enum Horoscope
    {
        Aries = 1,
        Aquarius,
        Cancer,
        Leo,
        Libra,
        Gemini,
        Taurus,
        Virgo,
        Scorpio,
        Capricorn,
        Pisces
    }
}