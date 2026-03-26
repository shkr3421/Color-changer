https://github.com/PaarvathiSubramanian/BMI-Calculator
{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
 
  "parameters": {
    "location": {
      "type": "string",
      "defaultValue": "centralus",
      "metadata": {
        "description": "Location for all resources."
      }
    },
    "adminUsername": {
      "type": "string",
      "defaultValue": "azureuser",
      "metadata": {
        "description": "Admin username for the VM."
      }
    },
    "adminPassword": {
      "type": "securestring",
      "metadata": {
        "description": "Admin password for the VM."
      }
    },
    "vmName": {
      "type": "string",
      "defaultValue": "myVM",
      "metadata": {
        "description": "Name of the virtual machine."
      }
    }
  },
 
  "variables": {
    "vnetName": "myVnet",
    "subnetName": "mySubnet",
    "nicName": "myNIC",
    "storageName": "[concat('stg', uniqueString(resourceGroup().id))]",
    "osDiskName": "[concat('osdisk-', uniqueString(resourceGroup().id))]"
  },
 
  "resources": [
    {
      "type": "Microsoft.Network/virtualNetworks",
      "apiVersion": "2023-02-01",
      "name": "[variables('vnetName')]",
      "location": "[parameters('location')]",
      "properties": {
        "addressSpace": {
          "addressPrefixes": [
            "10.0.0.0/16"
          ]
        },
        "subnets": [
          {
            "name": "[variables('subnetName')]",
            "properties": {
              "addressPrefix": "10.0.0.0/24"
            }
          }
        ]
      }
    },
 
    {
      "type": "Microsoft.Network/networkInterfaces",
      "apiVersion": "2023-02-01",
      "name": "[variables('nicName')]",
      "location": "[parameters('location')]",
      "dependsOn": [
        "[resourceId('Microsoft.Network/virtualNetworks', variables('vnetName'))]"
      ],
      "properties": {
        "ipConfigurations": [
          {
            "name": "ipconfig1",
            "properties": {
              "subnet": {
                "id": "[resourceId('Microsoft.Network/virtualNetworks/subnets', variables('vnetName'), variables('subnetName'))]"
              },
              "privateIPAllocationMethod": "Dynamic"
            }
          }
        ]
      }
    },
 
    {
      "type": "Microsoft.Storage/storageAccounts",
      "apiVersion": "2022-09-01",
      "name": "[variables('storageName')]",
      "location": "[parameters('location')]",
      "sku": {
        "name": "Standard_LRS"
      },
      "kind": "StorageV2",
      "properties": {}
    },
 
    {
      "type": "Microsoft.Compute/virtualMachines",
      "apiVersion": "2023-03-01",
      "name": "[parameters('vmName')]",
      "location": "[parameters('location')]",
      "dependsOn": [
        "[resourceId('Microsoft.Network/networkInterfaces', variables('nicName'))]",
        "[resourceId('Microsoft.Storage/storageAccounts', variables('storageName'))]"
      ],
      "properties": {
        "hardwareProfile": {
          "vmSize": "Standard_B1s"
        },
        "osProfile": {
          "computerName": "[parameters('vmName')]",
          "adminUsername": "[parameters('adminUsername')]",
          "adminPassword": "[parameters('adminPassword')]"
        },
        "storageProfile": {
          "imageReference": {
            "publisher": "Canonical",
            "offer": "UbuntuServer",
            "sku": "18.04-LTS",
            "version": "latest"
          },
          "osDisk": {
            "createOption": "FromImage",
            "managedDisk": {
              "storageAccountType": "Standard_LRS"
            },
            "name": "[variables('osDiskName')]"
          }
        },
        "networkProfile": {
          "networkInterfaces": [
            {
              "id": "[resourceId('Microsoft.Network/networkInterfaces', variables('nicName'))]"
            }
          ]
        }
      }
    }
  ],
 
  "outputs": {
    "vnetName": {
      "type": "string",
      "value": "[variables('vnetName')]"
    },
    "subnetName": {
      "type": "string",
      "value": "[variables('subnetName')]"
    },
    "nicName": {
      "type": "string",
      "value": "[variables('nicName')]"
    },
    "storageAccount": {
      "type": "string",
      "value": "[variables('storageName')]"
    },
    "vmName": {
      "type": "string",
      "value": "[parameters('vmName')]"
    }
  }
}
