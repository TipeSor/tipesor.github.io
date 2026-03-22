using TipeWeb.Abstractions;

[Page("/test")]
public partial class TestPage
{
    [Text]
    public string ValueText => $"Value: {Value}";

    [Slider]
    public double Value
    {
        get;
        set { field = value; if (AddOnChange) Values.Add(value); }
    }

    [Checkbox(Label = "Add on change ")]
    public bool AddOnChange;

    [Button]
    public void Add() { Values.Add(Value); }

    [TextList(
        Element = HtmlElement.Paragraph,
        WidthPx = 100,
        HeightPx = 200)]
    public List<double> Values = [];
}
