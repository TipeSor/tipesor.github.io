const apiUrl = `https://api.github.com/users/TipeSor/repos?sort=updated&per_page=5`;
async function fetchProjects() {
    try {
        const response = await fetch(apiUrl);
        const data = await response.json();

        const projectList = document.getElementById('project-list');
        
        projectList.innerHTML = '';

        data.filter(project => project.name.startsWith('ShadyKnight-'))
            .forEach(project => {
                const li = document.createElement('li');
                li.classList.add('project-item');

                // Create a link for the project
                const link = document.createElement('a');
                link.href = project.html_url;
                link.target = '_blank';
                link.textContent = project.name;

                li.appendChild(link);
                projectList.appendChild(li);
            });
    } catch (error) {
        console.error('Error fetching GitHub projects:', error);
    }
}

fetchProjects();