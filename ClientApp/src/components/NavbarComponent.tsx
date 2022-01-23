import React from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import CssBaseline from '@mui/material/CssBaseline';
import { Link } from 'react-router-dom';
import LoggedInOrLoggedOut from './LoggedInOrLoggedOut';

export default function NavbarComponent() {
  const [anchorNav, setAnchorNav] = React.useState(null);

  const handleOpenMenu = (e: any) => {
    setAnchorNav(e.currentTarget);
  };

  const handleCloseMenu = () => {
    setAnchorNav(null);
  };

  return (
    <AppBar position='static' sx={{ boxShadow: 'none' }}>
      <CssBaseline />
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
          <LoggedInOrLoggedOut
            handleOpenMenu={handleOpenMenu}
            handleCloseMenu={handleCloseMenu}
            anchorNav={anchorNav}
          />
        </Toolbar>
      </Container>
    </AppBar>
  );
}
