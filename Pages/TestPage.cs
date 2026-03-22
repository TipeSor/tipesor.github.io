using TipeWeb.Abstractions;

[Page("/about", Title = "About")]
public partial class AboutPage
{
    [Link(Href = "/")]
    public string ToHome => "home :3";

    [Section]
    public class AboutMe(AboutPage page)
    {
        [Text(Element = HtmlElement.Heading2)]
        public string Title => "About me";

        [TextList(
            BorderStyle = NodeBorder.None,
            Element = HtmlElement.Paragraph)]
        public List<string> Info = [
            "I'm Tipe",
            "I'm a C# hobbyist who has been coding for 3 years and enjoys making random projects."
        ];
    }

    [Section]
    public class AboutThis()
    {
        [Text(Element = HtmlElement.Heading2)]
        public string Title => "About this";

        [TextList(
            BorderStyle = NodeBorder.None,
            Element = HtmlElement.Paragraph)]
        public List<string> Info = [
            "This is made using TipeWeb. My custom web framework",
            "It creates pages out of just c# code",
            "It's built ontop of blazor wasm, and lets me make sites like this one"
        ];

        [Text(Element = HtmlElement.Heading3)]
        public string _ => "It can also have reactive elements";

        [Text]
        [Slider]
        public double Value;

        [Text(Element = HtmlElement.Heading3)]
        public string __ => "It can have lists";

        [Input(
            Placeholder = "Write here",
            OnEnter = nameof(Add))]
        public string Message = "";

        [Button]
        public void Add()
        {
            if (string.IsNullOrEmpty(Message))
                return;

            Messages.Add(Message);
            Message = "";
        }

        [TextList(
            EmptyText = "No messages added",
            Element = HtmlElement.Paragraph,
            HeightPx = 200)]
        public List<string> Messages = [];
    }

    [Section]
    public class ToggleExampe
    {
        [Text(Element = HtmlElement.Heading3)]
        public string _ => "It can have sections that toggle";

        public bool LoggedIn = false;
        public bool NotLoggedIn => !LoggedIn;

        public string Name = "";

        [Section(
            ShowWhen = nameof(NotLoggedIn),
            Style = "display:flex;align-items:center;gap:12px;")]
        public sealed class LoginSection(ToggleExampe Page)
        {
            [Input(
                Placeholder = "Enter your username",
                OnEnter = nameof(Login))]
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
        public sealed class PageSection(ToggleExampe Page)
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
}
