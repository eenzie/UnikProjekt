using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using UnikProjekt.Application.Helpers;

namespace UnikProjekt.Infrastructure.Database.EntityConfiguration;

public class UnitOfWork : IUnitOfWork
{
    private readonly UnikDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(UnikDbContext context)
    {
        _context = context;
    }

    void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
    {
        if (_context.Database.CurrentTransaction != null) return;
        _transaction = _context.Database.BeginTransaction(isolationLevel);
    }

    void IUnitOfWork.Commit()
    {
        if (_transaction == null)
            throw new Exception("You must call 'BeginTransaction' before Commit is called");
        _transaction.Commit();
        _transaction.Dispose();
    }

    void IUnitOfWork.Rollback()
    {
        if (_transaction == null) throw new Exception("You must call 'BeginTransaction' before Rollback is called");
        _transaction.Rollback();
        _transaction.Dispose();
    }
}
