using System.Text.Json;
using System.Text.Json.Serialization;

namespace SevDocs.Templates;

public class TemplateJobConverter : JsonConverter<ITemplate>
{
    public override ITemplate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);

        JsonElement GetProperty(string propertyName) => doc.RootElement.GetProperty(propertyName);
        string GetString(string propertyName) => GetProperty(propertyName).GetString();
        Type GetType(string propertyName) => Type.GetType(GetString(propertyName), true);

        var viewModelType = GetType(nameof(Payload.ModelType));
        var viewModelRaw = GetProperty(nameof(Payload.ViewModel)).GetRawText();

        return new Template
        {
            Subject = GetString(nameof(Payload.Subject)),
            ViewType = GetType(nameof(Payload.ViewType)),
            ViewModel = JsonSerializer.Deserialize(viewModelRaw, viewModelType, options)
        };
    }

    public override void Write(Utf8JsonWriter writer, ITemplate value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString(nameof(Payload.Subject), value.Subject);
        writer.WriteString(nameof(Payload.ViewType), value.ViewType.AssemblyQualifiedName);

        var modelType = value.ViewModel.GetType();
        writer.WriteString(nameof(Payload.ModelType), modelType.AssemblyQualifiedName);

        writer.WritePropertyName(nameof(Payload.ViewModel));
        JsonSerializer.Serialize(writer, value.ViewModel, modelType, options);

        writer.WriteEndObject();
    }

    private record Payload(string Subject, Type ViewType, object ViewModel, Type ModelType);

    private class Template : ITemplate
    {
        public string Subject { get; set; }
        public Type ViewType { get; set; }
        public object ViewModel { get; set; }
    }
}
