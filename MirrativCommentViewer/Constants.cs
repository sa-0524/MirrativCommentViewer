using System.Text.RegularExpressions;

namespace MirrativCommentViewer
{
    /// <summary>
    /// 定数定義
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// APIのURL
        /// </summary>
        public const string APIUrl = "https://www.mirrativ.com/api/live/live_comments?live_id=";

        /// <summary>
        /// API呼び出し周期（ミリ秒）
        /// </summary>
        public const int RequestInterval = 3000;

        /// <summary>
        /// API結果OK
        /// </summary>
        public const int StatusOK = 1;

        /// <summary>
        /// URLパターン
        /// </summary>
        public static readonly Regex urlPattern = new Regex(@"^https://www.mirrativ.com/live/([\w\-]+)$");
    }
}
