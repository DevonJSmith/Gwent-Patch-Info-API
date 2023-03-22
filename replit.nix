{ pkgs }: {
	deps = [
		pkgs.sqlite.bin
  pkgs.dotnet-sdk
    pkgs.omnisharp-roslyn
	];
}