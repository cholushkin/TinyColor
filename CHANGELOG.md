# Changelog

All notable changes to this package will be documented in this file.

## [1.1.0] - 2026-10-30

### Changed

- Renamed package id from `com.egg.tinycolor` to `com.qcat.tinycolor`.
- `changelogUrl` now points at this file instead of a placeholder URL.

### Fixed

- `Runtime/ColorScheme/Palettes/Editor/` contained Editor-only tooling (palette/atlas creator
  wizards using `UnityEditor` and the third-party `Alchemy.Inspector` package) with no assembly
  definition of its own, so it compiled as part of the all-platform `Egg.TinyColor.Runtime`
  assembly. Added a scoped `Egg.TinyColor.Editor.asmdef` (`includePlatforms: ["Editor"]`) so this
  tooling no longer ships into player builds.

## [1.0.0]

- Initial release: color manipulation/conversion utilities, color scheme and palette tools,
  `Samples~/Demonstration` and `Samples~/ExamplePrintAllColors` optional samples.
