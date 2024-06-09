const buttons = document.querySelectorAll('.button');
const contentSections = document.querySelectorAll('.content-section');

buttons.forEach(button => {
    button.addEventListener('click', () => {
        const contentId = button.classList.contains('documentation') ? 'documentation' : 'how-to-use';
        contentSections.forEach(section => {
            section.classList.remove('active'); // Deactivate all content sections
            if (section.id === contentId) {
                section.classList.add('active'); // Activate the clicked button's content section
            }
        });
    });
});
