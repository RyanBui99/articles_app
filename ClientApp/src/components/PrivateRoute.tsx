import React from 'react';
import { useSelector } from 'react-redux';
import { Navigate } from 'react-router-dom';
import Authentication from '../helpers/Authentication';

interface Props {
  component: React.ComponentType;
  path?: string;
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

  if (isAuthenticated && userHasRequiredRole) {
      console.log('authorized')
    return <RouteComponent />;
  }

  if (isAuthenticated && !userHasRequiredRole) {
    console.log('NOT authorized')
    return (
      <>
        <h1>asdf</h1>
      </>
    );
  }

  return (
    <>
      <h1>adsfasdf</h1>
    </>
  );
}
