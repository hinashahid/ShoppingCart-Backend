using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WealthO2.Mda.Reporting.Application.Interfaces;
using WealthO2.Mda.Reporting.Application.Interfaces.Repositories;
using WealthO2.Mda.Reporting.Domain.Entities;

namespace WealthO2.Mda.Reporting.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICommandDbContext _context;
        private readonly ILogger<ReportRequestRepository> _logger;
        public ReportRequestRepository(ICommandDbContext context, ILogger<ReportRequestRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task AddAsync(ReportRequest reportRequest, CancellationToken cancellationToken)
        {