using TipeWeb.Abstractions;

[Page("/", Title = "Home")]
public partial class HomePage
{
    [Text(Element = HtmlElement.Heading1)]
    public string Title => "Welcome to Tipes page";

    [Text]
    public string Deccription => "This site is a personal site for me :3";

    [Link(Href = "/about")]
    public string ToTest => "about";
}
