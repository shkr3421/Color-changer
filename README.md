param storageName string = 'mystorage12345'
param location string = 'eastus'
 
resource storageAccount 'Microsoft.Storage/storageAccounts@2022-09-01' = {
 name: storageName
 location: location
 sku: {
   name: 'Standard_LRS'
 }
 kind: 'StorageV2'
}
