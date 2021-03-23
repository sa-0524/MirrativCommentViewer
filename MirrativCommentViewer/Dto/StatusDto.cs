namespace MirrativCommentViewer.Dto
{
    /// <summary>
    /// ステータス
    /// </summary>
    public class StatusDto
    {
        public string captcha_url { get; set; }
        public string error { get; set; }
        public int error_code { get; set; }
        public string message { get; set; }
        public string msg { get; set; }
        public int ok { get; set; }
    }
}
