using Ubee.Domain.Entities;

namespace Ubee.Service.DTOs
{
    public class InfoCreationDto
    {
        public decimal AnnualExpose { get; set; }
        public decimal MonthlyExpose { get; set; }
        public decimal WeeklyExpose { get; set; }
        public decimal DailyExpose { get; set; }
        public DateTime DailyExposeDate { get; set; }
        public decimal SumRecord { get; set; }
        public DateTime SumRecordDate { get; set; }

        public long WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
