namespace SevDocs.Templates;

public interface ITemplate
{
    string Subject { get; }
    Type ViewType { get; }
    object ViewModel { get; }
}
