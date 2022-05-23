using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace S7CristhianMotoche9A
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
