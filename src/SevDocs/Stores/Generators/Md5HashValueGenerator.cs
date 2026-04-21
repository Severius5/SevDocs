using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Security.Cryptography;

namespace SevDocs.Stores.Configs;

internal class Md5HashValueGenerator : ValueGenerator<string>
{
    public override bool GeneratesTemporaryValues => false;

    public override string Next(EntityEntry entry)
    {
        dynamic entity = entry.Entity;
        Ulid id = entity.Id;

        return Convert.ToHexString(MD5.HashData(id.ToByteArray()));
    }
}
