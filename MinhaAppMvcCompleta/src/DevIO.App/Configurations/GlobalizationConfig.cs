using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace DevIO.App.Configurations
{
	public static class GlobalizationConfig
	{
		public static IApplicationBuilder UseGlobalizationConfig(this IApplicationBuilder app) {

			//Configuração de Cultura
			var defaultCulture = new CultureInfo("pt-BR");
			var localizationOptions = new RequestLocalizationOptions {
				DefaultRequestCulture = new RequestCulture(defaultCulture),
				SupportedCultures = new List<CultureInfo> { defaultCulture },
				SupportedUICultures = new List<CultureInfo> { defaultCulture }
			};
			app.UseRequestLocalization(localizationOptions);
			//Fim

			return app;
		}
	}

}
