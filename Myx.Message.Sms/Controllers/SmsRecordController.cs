using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Myx.Core.Dtos;
using Myx.Core.Responses;
using Myx.Message.Core.Entities;
using Myx.Message.Core.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Myx.Message.Sms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsRecordController : Controller
    {

        private readonly IBaseRepository<SmsRecord, long> _smsRecordRepository;

        public SmsRecordController(IBaseRepository<SmsRecord, long> smsRecordRepository)
        {
            _smsRecordRepository = smsRecordRepository;
        }

        public async Task<IApiResult<MyxPageListDto<SmsRecord>>> GetPage(int pageNum, int pageSize)
        {
            var query = _smsRecordRepository.Querable().AsNoTracking().OrderByDescending(sr => sr.SendTime);
            var total = await query.CountAsync();
            var data = await query.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return new ApiResult<MyxPageListDto<SmsRecord>>(new MyxPageListDto<SmsRecord>(pageSize, pageNum, total, data));
        }
    }
}
