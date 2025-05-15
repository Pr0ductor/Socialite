document.addEventListener("DOMContentLoaded", function () {
    const dateFilters = document.querySelectorAll(".hidden-date-filter");

    dateFilters.forEach((filter) => {
        filter.addEventListener("change", function () {
            const selectedFilter = this.value;

            // Формируем URL с выбранным фильтром
            const url = new URL(window.location.href);
            url.searchParams.set("dateFilter", selectedFilter);

            // Перенаправляем пользователя на обновленный URL
            window.location.href = url.toString();
        });
    });
});