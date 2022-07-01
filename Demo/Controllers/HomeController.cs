using Microsoft.AspNetCore.Mvc;
using Hei.Captcha;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly SecurityCodeHelper _securityCode;

        public HomeController(SecurityCodeHelper securityCode)
        {
            _securityCode = securityCode;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 泡泡中文验证码 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> BubbleCode()
        {
            var code = _securityCode.GetRandomCnText(2);
            var imgbyte = await _securityCode.GetBubbleCodeByteAsync(code);

            return File(imgbyte, "image/png");
        }

        /// <summary>
        /// 数字字母组合验证码
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> HybridCodeAsync()
        {
            var code = _securityCode.GetRandomEnDigitalText(4);
            var imgbyte = await _securityCode.GetEnDigitalCodeByteAsync(code);

            return File(imgbyte, "image/png");
        }

        /// <summary>
        /// gif泡泡中文验证码 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GifBubbleCodeAsync()
        {
            var code = _securityCode.GetRandomCnText(2);
            var imgbyte = await _securityCode.GetGifBubbleCodeByteAsync(code);

            return File(imgbyte, "image/gif");
        }

        /// <summary>
        /// gif数字字母组合验证码
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GifHybridCodeAsync()
        {
            var code = _securityCode.GetRandomEnDigitalText(4);
            var imgbyte = await _securityCode.GetGifEnDigitalCodeByteAsync(code);

            return File(imgbyte, "image/gif");
        }
    }
}
