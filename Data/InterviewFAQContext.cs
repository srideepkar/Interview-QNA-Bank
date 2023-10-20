using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InterviewFAQ.Model;

namespace InterviewFAQ.Data
{
    public class InterviewFAQContext : DbContext
    {
        public InterviewFAQContext (DbContextOptions<InterviewFAQContext> options)
            : base(options)
        {
        }

        public DbSet<InterviewFAQ.Model.QNA> QNA { get; set; } = default!;
    }
}
