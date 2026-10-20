using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_Archive.Helpers
{
    public class ArchiveFileVM
    {
        internal object UserName;
        internal object DepName;

        public int ID { get; set; }
        public string FileName { get; set; }
        public string ArchiveTitle { get; set; }
        public string Category { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public long FileSize { get; set; }
        public byte[] FileData { get; set; } // بيانات الملف الخام
        public string FileExtension { get; set; } // امتداد الملف

       
     

        // خاصية لعرض الحجم بشكل مقروء
        public string FileSizeFormatted
        {
            get
            {
                string[] sizes = { "B", "KB", "MB", "GB" };
                int order = 0;
                double size = FileSize;

                while (size >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    size /= 1024;
                }

                return $"{size:N2} {sizes[order]}";
            }
        }

        // خاصية لعرض التاريخ بشكل مقروء
        public string ArchiveDateFormatted => ArchiveDate?.ToString("yyyy/MM/dd");
    }
}