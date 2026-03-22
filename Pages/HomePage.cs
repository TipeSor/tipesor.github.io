using TipeWeb.Abstractions;

[Page("/", Title = "Home")]
public partial class HomePage
{
    [Text(Element = HtmlElement.Heading1)]
    public string Title => "TipeWeb Demo";

    [Text(Element = HtmlElement.Paragraph)]
    public string Intro => "Simple C#-first static site generator and UI framework.";

    [Link(Href = "/test")]
    public string TestPage => "/test";

    public bool LoggedIn = false;
    public bool NotLoggedIn => !LoggedIn;

    public string Name = "";

    [Section(
        ShowWhen = nameof(NotLoggedIn),
        Style = "display:flex;align-items:center;gap:12px;")]
    public sealed class LoginSection(HomePage Page)
    {
        [Input(OnEnter = nameof(Login))]
        public string Name = "";

        [Button]
        public void Login()
        {
            if (string.IsNullOrEmpty(Name))
                return;

            Page.Name = Name;
            Name = "";

            Page.LoggedIn = true;
        }
    }

    [Section(ShowWhen = nameof(LoggedIn))]
    public sealed class PageSection(HomePage Page)
    {
        [Text]
        public string Text => $"Logged in as: {Page.Name}";

        [Button]
        public void Logout()
        {
            Page.Name = "";
            Page.LoggedIn = false;
        }
    }
}
