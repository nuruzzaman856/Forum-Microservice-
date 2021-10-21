using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.PostReplies.Queries.GetAllPostReplyList
{
   public class GetAllPostRepliesListVm
    {

        public Guid PostReplyId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
