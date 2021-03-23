using System.Collections.Generic;

namespace MirrativCommentViewer.Dto
{
    /// <summary>
    /// API結果
    /// </summary>
    public class ResultDto
    {
        /// <summary>
        /// ステータス
        /// </summary>
        public StatusDto status { get; set; }

        /// <summary>
        /// コメント一覧
        /// </summary>
        public List<CommentDto> comments { get; set; }
    }
}
