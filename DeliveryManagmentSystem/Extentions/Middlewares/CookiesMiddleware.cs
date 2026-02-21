namespace DeliveryManagmentSystem.Extentions.Middlewares
{
    public class CookiesMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public CookiesMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {

           string? accessToken = context.Request.Cookies["AccessToken"];

           if(!string.IsNullOrWhiteSpace(accessToken))
           {
                context.Request.Headers["Authorization"] = $"Bearer {accessToken}";
           }

            await _requestDelegate.Invoke(context);
        }
    }
}
