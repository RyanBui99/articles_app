import React from 'react';
import { Navigate } from 'react-router-dom';
import Authentication from '../helpers/Authentication';

interface Props {
  component: React.ComponentType;
//   path?: string;
  role: string;
}

export default function PrivateRoute({
  component: RouteComponent,
  role,
}: Props) {
  const user = Authentication.getUser();
  const isAuthenticated = user.id;
  const userRole = user.role;
  const userHasRequiredRole = userRole == role ? true : false;

  if (isAuthenticated && userHasRequiredRole) return <RouteComponent />;

  if (isAuthenticated && !userHasRequiredRole) return <Navigate to='/' />;

  return <Navigate to='/' />;
}
