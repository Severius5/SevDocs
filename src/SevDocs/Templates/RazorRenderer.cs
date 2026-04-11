using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace SevDocs.Templates;

internal class RazorRenderer(HtmlRenderer htmlRenderer) : ITemplateRenderer
{
    public Task<string> RenderAsync(ITemplate template)
    {
        return htmlRenderer.Dispatcher.InvokeAsync(async () =>
        {
            var output = await htmlRenderer.RenderComponentAsync(
                template.ViewType,
                ParameterView.FromDictionary(new Dictionary<string, object>
                {
                    { "Model", template.ViewModel }
                }));

            return output.ToHtmlString();
        });
    }
}