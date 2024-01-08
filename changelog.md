# Changelog

## 0.1.0
- Initial release

## 0.1.1
- Added `ModuleBuilder`

## 0.2.0
- Update Autofac to 5.1.
- Add support for .NET Standard 2.0.

## 0.2.1
* Add compatibility for Autofac 6.x.
* Only depend on `System.Collections.Immutable` when targeting .NET Standard.

## 1.0.0
* Remove upper constraint on `System.Collections.Immutable`
* Add symbols package
* Add `[Pure]` attributes to pure builder methods

## 1.1.0
* Add a new `Configure` method on `CompositionRootBuilder` that allows
  arbitrary setup code to run on the underlying `ContainerBuilder`.

## 1.1.2
* Add `TargetFramework` `net8.0`.
* Remove `TargetFramework` `netcoreapp3.1`.
* Update `Autofac` to `7.1.0`.
