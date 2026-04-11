namespace SevDocs.Templates;

public interface ITemplateRenderer
{
    Task<string> RenderAsync(ITemplate template);
}
