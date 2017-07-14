# IdentityServer4.MongoDB

Identity store using MongoDB

[![Build status](https://ci.appveyor.com/api/projects/status/y90w6m5e0rdy0n8o?svg=true)](https://ci.appveyor.com/project/collabco/identityserver4-mongodb)


### IIdentityServerBuilder extensions:
```csharp
services.AddIdentityServer()
        .ConfigureConfigurationDBOption(option =>
        {
            option.ConnectionString = "mongodb://192.168.103.115:27017";
            option.Database = "IdentityServer";
        })
        .ConfigureOperationMongoDBOption(option =>
        {
            option.ConnectionString = "mongodb://192.168.103.115:27017";
            option.Database = "IdentityServer";
        })
        .AddConfigurationStore()
        .AddOperationalStore();
```

### IApplicationBuilder extensions:
```csharp
services.UseIdentityServerMongoDBTokenCleanup(applicationLifetime);
```
