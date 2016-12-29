using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EPiServer.Reference.Commerce.Site.Features.Generator.Pages
{
    [ContentType(DisplayName = "Generator catalog content", GUID = "43000bdf-731c-47d2-ae46-001df01dd679", Description = "", AvailableInEditMode = true)]
    public class CatalogContentGeneratorPage : PageData
    {
        [CultureSpecific]
        [Display(
               Name = "Generator  catalog content",
               Description = "Title for the Generator  catalog content",
               GroupName = SystemTabNames.Content,
               Order = 1)]
        public virtual string Title { get; set; }
    }
}