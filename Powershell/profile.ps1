function get-gitstatus { git status }
function add-commit-git
{ 
	git add .
	git add -u
	git commit
}

Set-Alias -Name gs -Value get-gitstatus
Set-Alias -Name gtc -Value add-commit-git
