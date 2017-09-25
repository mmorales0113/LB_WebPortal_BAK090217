using System.Collections.Generic;
using WebPortal.Auditing.Dto;
using WebPortal.Dto;

namespace WebPortal.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
