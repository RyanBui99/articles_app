import React from 'react';
import { Provider } from 'react-redux';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import PrivateRoute from './components/PrivateRoute';
import AdminPage from './pages/adminPage/AdminPage';
import BlogPage from './pages/blogPage/BlogPage';
import DetailedBlogPostPage from './pages/detailedBlogPostPage/DetailedBlogPostPage';
import LoginPage from './pages/loginPage/LoginPage';
import RegisterPage from './pages/registerPage/RegisterPage';
import { store } from './store/store';

function App() {
  return (
    <div className='App'>
      <Provider store={store}>
        <BrowserRouter>
          <Routes>
            <Route path='/login' element={<LoginPage />} />
            <Route path='/register' element={<RegisterPage />} />
            <Route
              path='/admin/dashboard'
              element={<PrivateRoute component={AdminPage} role='admin' />}
            />
            <Route path='/' element={<BlogPage />} />
            <Route path='/blogPost/:id' element={<DetailedBlogPostPage />} />
          </Routes>
        </BrowserRouter>
      </Provider>
    </div>
  );
}

export default App;
