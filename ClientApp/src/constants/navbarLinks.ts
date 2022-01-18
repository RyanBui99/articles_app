import { Link } from 'react-router-dom';

export const navbarLinks = {
  adminLinks: [
    {
      linkName: 'Dashboard',
      link: '/admin/dashboard',
      component: Link,
    },
    {
      linkName: 'Log out',
      link: '/',
      component: Link,
    },
  ],
  userLinks: [
    {
      linkName: 'Log out',
      link: '/',
      component: Link,
    },
  ],
  navLinks: [
    {
      linkName: 'Log in',
      link: '/login',
      component: Link,
    },
    {
      linkName: 'Register',
      link: '/register',
      component: Link,
    },
  ],
};
