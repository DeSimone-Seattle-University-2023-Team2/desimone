using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Presentation.Configuration;

public sealed class RenderModeInteractiveServer : RenderModeAttribute
{
    public override IComponentRenderMode Mode => RenderMode.InteractiveServer;
}