using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EPiServer.Reference.Commerce.Site.Features.Start.Pages
{
    [ContentType(DisplayName = "Generator page", GUID = "43000bdf-731c-47d2-ae46-001df01dd678", Description = "", AvailableInEditMode = true)]
    public class CartGeneratorPage : PageData
    {
        [CultureSpecific]
        [Display(
               Name = "Generator title",
               Description = "Title for the Generator page",
               GroupName = SystemTabNames.Content,
               Order = 1)]
        public virtual string Title { get; set; }
    }
}