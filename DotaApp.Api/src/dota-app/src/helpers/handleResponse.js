import { userService } from '../services';

export const handleResponse = (response) => {
  return response.text().then(text => {
    const data = text && JSON.parse(text);
    if (!response.ok) {
      if (response.status === 401) {
        // auto logout if 401 response returned from api
        userService.logout();
        window.location.reload(true);
      }

      let serverErrors = '';

      if (data.errors) {
        Object.keys(data.errors).forEach(key => {
            serverErrors += `${data.errors[key]}`;
        });
      } else if (data.message) {
        serverErrors = data.message;
      }

      const error = serverErrors || response.statusText;
      return Promise.reject(error);
    }

    return data;
  });
};