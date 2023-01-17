namespace Chinook.RepositoryEF.Interfaces;
using System.Collections.Generic;

public interface IRepository<T> 
{
    /// <summary>
    /// Get details by id
    /// </summary>
    /// <param name="id">primary key of the model</param>
    /// <returns></returns>
    public Task<T> GetById(long id);
    /// <summary>
    /// insert a new data row to a table 
    /// </summary>
    /// <param name="obj"> object from current model</param>
    /// <returns></returns>
    public Task<int> Create(T obj);
    /// <summary>
    /// Update a existing row in a table
    /// </summary>
    /// <param name="obj">object from current model with updated</param>
    /// <returns></returns>
    Task<int> Update(T obj);
    /// <summary>
    /// Delete a existing row from table
    /// </summary>
    /// <param name="obj">object from </param>
    /// <returns></returns>
    Task<int> Delete(T obj);
}

