import React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import { makeStyles } from '@mui/styles';
import IconButton from '@mui/material/IconButton';
import CssBaseline from '@mui/material/CssBaseline';

const useStyles = makeStyles({
  root: {
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
  },
});

export default function Header() {
  const classes = useStyles();
  return (
    <AppBar position='static' className={classes.root}>
      <CssBaseline />
      <Toolbar>
        <IconButton
          size='large'
          edge='start'
          color='inherit'
          aria-label='menu'
          sx={{ mr: 2 }}
        ></IconButton>
        <Typography variant='h4' component='div' sx={{ flexGrow: 1 }}>
          Articles
        </Typography>
      </Toolbar>
    </AppBar>
  );
}
