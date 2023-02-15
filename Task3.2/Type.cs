using System.ComponentModel.DataAnnotations;

namespace Task3_2;

[Serializable]
public enum Type
{
    [Display(Name="Касетний")]
    CassetteDeck,
    [Display(Name="Котушковий")]
    HelicalScan,
    [Display(Name="Магнітола")]
    WireRecording
}