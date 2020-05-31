using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace DevIO.App.Extensions
{
	[HtmlTargetElement("*", Attributes = "supress-by-claim-name")]
	[HtmlTargetElement("*", Attributes = "supress-by-claim-value")]
	public class ApagElementoByClaimTahHelper : TagHelper
	{
		private readonly IHttpContextAccessor _contextAccessor;
		public ApagElementoByClaimTahHelper(IHttpContextAccessor contextAccessor) {
			_contextAccessor = contextAccessor;
		}

		[HtmlAttributeName("supress-by-claim-name")]
		public string IdentityClaimName { get; set; }

		[HtmlAttributeName("supress-by-claim-value")]
		public string IdentityClaimValue { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output) {

			if(context == null)
				throw new ArgumentNullException(nameof(context));

			if(output == null)
				throw new ArgumentNullException(nameof(output));

			var temAcesso = CustomAuthorization.ValidarClaimsUsuario(_contextAccessor.HttpContext, IdentityClaimName, IdentityClaimValue);

			if(temAcesso) return;

			output.SuppressOutput();
		}
	}

	[HtmlTargetElement("a", Attributes = "disable-by-Claim-name")]
	[HtmlTargetElement("a", Attributes = "disable-by-Claim-value")]
	public class DesabilitaLinkByClaimTagHelper : TagHelper
	{
		private readonly IHttpContextAccessor _contextAccessor;

		public DesabilitaLinkByClaimTagHelper(IHttpContextAccessor contextAccessor) {
			_contextAccessor = contextAccessor;
		}

		[HtmlAttributeName("disable-by-claim-name")]
		public string IdentityClaimName { get; set; }

		[HtmlAttributeName("disable-by-claim-value")]
		public string IdentityClaimValue { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output) {

			if(context == null)
				throw new ArgumentNullException(nameof(context));

			if(output == null)
				throw new ArgumentNullException(nameof(output));

			var temAcesso = CustomAuthorization.ValidarClaimsUsuario(_contextAccessor.HttpContext, IdentityClaimName, IdentityClaimValue);

			if(temAcesso) return;

			output.Attributes.RemoveAll("href");
			output.Attributes.Add(new TagHelperAttribute("style", "cursor: not-allowed"));
			output.Attributes.Add(new TagHelperAttribute("title", "Você não tem permissão"));
		}
	}

	/*Tag Helper para exibir o botão ou não, exemplo, se a tela está vindo do Edit
	 * ex: fornecedor Edit, o botão de editar do endereço ficará visívell, caso estiver em modo visualização no fornecedor, o botão de edição do endereço não irá ficar visível*/

	[HtmlTargetElement("*", Attributes = "supress-by-action")]
	public class ApagaElementoByActionTagHelper : TagHelper
	{
		private readonly IHttpContextAccessor _contextAccessor;

		public ApagaElementoByActionTagHelper(IHttpContextAccessor contextAccessor) {
			_contextAccessor = contextAccessor;
		}

		[HtmlAttributeName("supress-by-action")]
		public string ActionName { get; set; }


		public override void Process(TagHelperContext context, TagHelperOutput output) {

			if(context == null)
				throw new ArgumentNullException(nameof(context));

			if(output == null)
				throw new ArgumentNullException(nameof(output));

			var action = _contextAccessor.HttpContext.GetRouteData().Values["action"].ToString();
			if(ActionName.Contains(action)) return;

			output.SuppressOutput();
		}
	}

}
