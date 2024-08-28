# 1 - app-sensitive.config deve estar preenchido corretamente
# 2 - Alterar o _earlyboundsettings.json informanto as entidades que devem ser geradas
# 3 - Abrir o PowerShell como admin
# 4 - Abrir o arquivo atual no PowerShell
# 5 - Rodar 


# Set-ExecutionPolicy -ExecutionPolicy Bypass -Scope Process --> Se ocorrer erro por falta de assinnatura rogar esse comando


Clear-Host
$root = (Get-Location).Path
$sensitiveConfig = $root -replace "plugins-default-plugins\\earlybound", "plugins-default-connection\app-sensitive.config"
Write-Host $sensitiveConfig

$xmlContent = Get-Content -Path $sensitiveConfig
$xml = [xml]$xmlContent
$settings = @{}

foreach ($add in $xml.configuration.appSettings.add) {
    $key = $add.GetAttribute("key")
    $value = $add.GetAttribute("value")
    $settings[$key] = $value
}

pac auth create -n $settings["friendlyName"] -env $settings["url"] -t $settings["tenantid"] -id $settings["applicationid"] -cs $settings["secret"]
pac auth select -n $settings["friendlyName"]
pac modelbuilder build -o $root -stf "$root\_earlyboundsettings.json"