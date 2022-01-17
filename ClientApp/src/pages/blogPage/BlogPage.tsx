import React from 'react';
import Articles from '../../components/Articles';
import NavbarComponent from '../../components/NavbarComponent';
import Grid from '@mui/material/Grid';

export default function BlogPage() {
  return (
    <>
      <NavbarComponent />
      <Grid justifyContent='center' sx={{ flexGrow: 1 }} container spacing={3} marginTop='2em'>
        {[0, 1, 2, 3].map((value: number) => (
          <Grid key={value} item>
            <Articles />
          </Grid>
        ))}
      </Grid>
    </>
  );
}
