using System;

namespace MirrativCommentViewer.Dto
{
    /// <summary>
    /// コメント
    /// </summary>
    public class CommentDto
    {
        /// <summary>
        /// バッジ画像（未確認）
        /// </summary>
        public string badge_image_url { get; set; }

        /// <summary>
        /// コメント
        /// </summary>
        public string comment { get; set; }

        /// <summary>
        /// 投稿日時
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        /// コメントID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// （未確認）
        /// </summary>
        public int is_continuous_streamer { get; set; }

        /// <summary>
        /// モデレータか
        /// </summary>
        public int is_moderator { get; set; }

        /// <summary>
        /// プロフィール画像
        /// </summary>
        public string profile_image_url { get; set; }

        /// <summary>
        /// ユーザID
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// ユーザ名
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        /// 投稿日時
        /// </summary>
        public DateTimeOffset CreateDateTime
        {
            get
            {
                return DateTimeOffset.FromUnixTimeSeconds(long.Parse(created_at)).ToLocalTime();
            }
        }

        /// <summary>
        /// 投稿日時（テキスト）
        /// </summary>
        public string CreateDateText
        {
            get
            {
                return CreateDateTime.ToString("MM/dd HH:mm:ss");
            }
        }
    }
}
