## Description 
Global Weather is a dynamic web application offering weather analysis and prediction.
Users can pick any location on the map to generate a weather report as well as charts.

## Configuration 
No configuration is needed.
The project can be published in github pages using github action.
```
name: Deploy to GitHub Pages
on:
  push:
    branches: [ master ]
jobs:
  deploy-to-github-pages:
    # use ubuntu-latest image to run steps on
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v2
    - name: Setup .NET Core SDK
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 6.0.307
    - name: Publish .NET Core Project
      run: dotnet publish ./Weather.sln -c Release -o release --nologo
    # changes the base-tag in index.html from '/' to 'BlazorGitHubPagesDemo' to match GitHub Pages repository subdirectory
    - name: Change base-tag in index.html from / to weather2
      run: sed -i 's/<base href="\/" \/>/<base href="\/weather2\/" \/>/g' release/wwwroot/index.html
      # copy index.html to 404.html to serve the same file when a file is not found
    - name: copy index.html to 404.html
      run: cp release/wwwroot/index.html release/wwwroot/404.html
      # add .nojekyll file to tell GitHub pages to not treat this as a Jekyll project. (Allow files and folders starting with an underscore)
    - name: Add .nojekyll file
      run: touch release/wwwroot/.nojekyll
      
    - name: Commit wwwroot to GitHub Pages
      uses: JamesIves/github-pages-deploy-action@3.7.1
      with:
        GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
        BRANCH: gh-pages
        FOLDER: release/wwwroot
```

## To Do
 - Write the section to explain the design
 - Improve performance by decreasing the initial loadtime
