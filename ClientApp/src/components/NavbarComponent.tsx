import React from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { Link } from 'react-router-dom';
import LoggedInOrLoggedOut from './LoggedInOrLoggedOut';
import { CssBaseline } from '@material-ui/core';

export default function NavbarComponent() {
  return (
    <>
    <CssBaseline />
    <AppBar position='static' sx={{ boxShadow: 'none' }}>
      <Container maxWidth='xl'>
        <Toolbar disableGutters>
          <Typography
            variant='h6'
            noWrap
            component='div'
            sx={{ flexGrow: 1, mr: 2, display: { xs: 'none', md: 'flex' } }}
          >
            <Link to='/' style={{ textDecoration: 'none', color: 'inherit' }}>
              GigaBlog
            </Link>
          </Typography>
          <Typography
            variant='h6'
            noWrap
            component='div'
            sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}
          >
            <Link to='/' style={{ textDecoration: 'none', color: 'inherit' }}>
              GigaBlog
            </Link>
          </Typography>
          <LoggedInOrLoggedOut />
        </Toolbar>
      </Container>
    </AppBar>
    </>
  );
}
